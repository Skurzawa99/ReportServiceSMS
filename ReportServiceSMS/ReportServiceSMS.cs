using ReportServiceSMS.Core;
using ReportServiceSMS.Core.Repositories;
using SmsSender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace ReportServiceSMS
{
    public partial class ReportServiceSMS : ServiceBase
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly int _intervalInMinutes;
        private string _reciver; 
        private Timer _timer;

        private ErrorRepository _errorRepository = new ErrorRepository();
        private GenerateStringSms smsString = new GenerateStringSms();

        public ReportServiceSMS()
        {
            InitializeComponent();

            try
            {
                _reciver = ConfigurationManager.AppSettings["Reciver"];
                _intervalInMinutes = Convert.ToInt32(ConfigurationManager.AppSettings["IntervalInMinutes"]);
                _timer = new Timer(_intervalInMinutes * 60000);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        protected override void OnStart(string[] args)
        {
            _timer.Elapsed += DoWork;
            _timer.Start();
            Logger.Info("Service sterted...");
        }

        private void DoWork(object sender, ElapsedEventArgs e)
        {
            try
            {
                SendError();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void SendError()
        {
            var errors = _errorRepository.GetLastErrors(_intervalInMinutes);

            if (errors == null || !errors.Any())
                return;

            Sms.Send(smsString.GenerateErrors(errors, _intervalInMinutes), _reciver);

            Logger.Info("Error sent.");

        }

        protected override void OnStop()
        {
            Logger.Info("Service stopped...");
        }
    }
}
