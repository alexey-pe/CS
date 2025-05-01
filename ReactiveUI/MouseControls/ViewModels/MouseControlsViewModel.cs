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
                MouseButton = MouseButtonClick.Left,
                KeyboardButtons = KeyboardButtonFlag.Ctrl
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool IsLeftButtonClickChecked
        {
            get => IsMouseButtonChecked(MouseButtonClick.Left);

            set
            {
                if (GetSelectedMouseButton() != MouseButtonClick.Left)
                {
                    if (value)
                    {
                        SelectMouseButton(MouseButtonClick.Left);
                    }

                    OnPropertyChanged(nameof(IsLeftButtonClickChecked));
                }
            }
        }

        public bool IsRightButtonClickChecked
        {
            get => IsMouseButtonChecked(MouseButtonClick.Right);
            set
            {
                if (GetSelectedMouseButton() != MouseButtonClick.Right)
                {
                    if (value)
                    {
                        SelectMouseButton(MouseButtonClick.Right);
                    }

                    OnPropertyChanged(nameof(IsRightButtonClickChecked));
                }
            }
        }

        public bool IsScrollWheelClickChecked
        {
            get => IsMouseButtonChecked(MouseButtonClick.Wheel);
            set
            {
                if (GetSelectedMouseButton() != MouseButtonClick.Wheel)
                {
                    if (value)
                    {
                        SelectMouseButton(MouseButtonClick.Wheel);
                    }

                    OnPropertyChanged(nameof(IsScrollWheelClickChecked));
                }
            }
        }

        public bool IsRotateScrollWheelChecked
        {
            get => IsMouseButtonChecked(MouseButtonClick.RotateWheel);
            set
            {
                if (GetSelectedMouseButton() != MouseButtonClick.RotateWheel)
                {
                    if (value)
                    {
                        SelectMouseButton(MouseButtonClick.RotateWheel);
                    }

                    OnPropertyChanged(nameof(IsRotateScrollWheelChecked));
                }
            }
        }

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

        private bool IsMouseButtonChecked(MouseButtonClick mouseButtonClick)
        {
            return GetSelectedMouseButton() == mouseButtonClick;
        }

        private MouseButtonClick GetSelectedMouseButton() => _rotateSetup.MouseButton;

        private void SelectMouseButton(MouseButtonClick mouseButtonClick)
        {
            _rotateSetup.MouseButton = mouseButtonClick;
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
