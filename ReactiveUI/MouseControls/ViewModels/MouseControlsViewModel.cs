using System.ComponentModel;

using MouseControls.Domain;

namespace MouseControls.ViewModels
{
    public class MouseControlsViewModel : INotifyPropertyChanged
    {
        private ButtonsSetup _rotateSetup;

        public MouseControlsViewModel()
        {
            _rotateSetup = new ButtonsSetup()
            {
                KeyboardButtons = KeyboardButtonFlag.Ctrl
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool IsCtrlFlagChecked
        {
            get => (_rotateSetup.KeyboardButtons & KeyboardButtonFlag.Ctrl) != 0;
            set
            {
                if (value)
                {
                    _rotateSetup.KeyboardButtons |= KeyboardButtonFlag.Ctrl;
                }
                else
                {
                    _rotateSetup.KeyboardButtons &= ~KeyboardButtonFlag.Ctrl;
                }

                OnPropertyChanged(nameof(IsCtrlFlagChecked));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
