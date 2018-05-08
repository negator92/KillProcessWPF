using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KillProcess
{
    public class ApplicationViewModel : PropertyChangedClass
    {
        public TextBox TextBoxProcess { get; set; }

        public ApplicationViewModel()
            => KillProcessCommand = new RelayCommand(KillProcess,
                () => !(string.IsNullOrEmpty(ProcessName) && string.IsNullOrWhiteSpace(ProcessName)));

        public ICommand KillProcessCommand { get; set; }

        public string ProcessName { get; private set; }

        private void KillProcess()
        {
            if (ProcessName.Contains(".exe"))
                ProcessName.Replace(".exe", "");
            try
            {
                Process[] processNames = Process.GetProcessesByName(ProcessName);

                if (processNames.Length == 0)
                    MessageBox.Show($"{ProcessName} not found!");
                else
                {
                    foreach (Process process in processNames)
                        process.Kill();
                    MessageBox.Show($"{ProcessName} killed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error, {ex.Message}, {ex.StackTrace}");
            }
            finally
            {
                TextBoxProcess.SelectAll();
            }
        }
    }
}