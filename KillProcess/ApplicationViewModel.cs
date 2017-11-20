using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace KillProcess
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel()
        {
            KillProcessCommand = new RelayCommand(KillProcess, () => !(string.IsNullOrEmpty(ProcessName) && string.IsNullOrWhiteSpace(ProcessName)));
        }

        public ICommand KillProcessCommand { get; set; }

        public string ProcessName { get; private set; }

        private void KillProcess()
        {
            if (ProcessName.Contains(".exe"))
                ProcessName.Replace(".exe", "");
            try
            {
                foreach (Process p in Process.GetProcessesByName(ProcessName))
                    p.Kill();
                MessageBox.Show($"{ProcessName} seems killed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error, {ex.Message}, {ex.StackTrace}");
            }
        }
    }
}