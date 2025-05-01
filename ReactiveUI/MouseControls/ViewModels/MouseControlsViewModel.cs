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
            get => IsKeyboardButtonFlagSet(KeyboardButtonFlag.Ctrl);
            set
            {
                if (value)
                {
                    SetKeyboardButtonFlag(KeyboardButtonFlag.Ctrl);
                }
                else
                {
                    ClearKeyboardButtonFlag(KeyboardButtonFlag.Ctrl);
                }

                OnPropertyChanged(nameof(IsCtrlFlagChecked));
            }
        }

        private bool IsKeyboardButtonFlagSet(KeyboardButtonFlag keyboardButtonFlag)
        {
            return (_rotateSetup.KeyboardButtons & keyboardButtonFlag) != 0;
        }

        private void SetKeyboardButtonFlag(KeyboardButtonFlag keyboardButtonFlag)
        {
            _rotateSetup.KeyboardButtons |= keyboardButtonFlag;
        }

        private void ClearKeyboardButtonFlag(KeyboardButtonFlag keyboardButtonFlag)
        {
            _rotateSetup.KeyboardButtons &= ~keyboardButtonFlag;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
