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

        public bool IsAltFlagChecked
        {
            get => IsKeyboardButtonFlagSet(KeyboardButtonFlag.Alt);
            set
            {
                if (value)
                {
                    SetKeyboardButtonFlag(KeyboardButtonFlag.Alt);
                }
                else
                {
                    ClearKeyboardButtonFlag(KeyboardButtonFlag.Alt);
                }

                OnPropertyChanged(nameof(IsAltFlagChecked));
            }
        }

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

        public bool IsShiftFlagChecked
        {
            get => IsKeyboardButtonFlagSet(KeyboardButtonFlag.Shift);
            set
            {
                if (value)
                {
                    SetKeyboardButtonFlag(KeyboardButtonFlag.Shift);
                }
                else
                {
                    ClearKeyboardButtonFlag(KeyboardButtonFlag.Shift);
                }

                OnPropertyChanged(nameof(IsShiftFlagChecked));
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
