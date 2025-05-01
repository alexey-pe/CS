using Xunit;

using MouseControls.ViewModels;

namespace MouseControls.Tests
{
    public class MouseControlsViewModelTest
    {
        MouseControlsViewModel _mouseControlsViewModelWithFlagsCleared;
        MouseControlsViewModel _mouseControlsViewModelWithFlagsSet;

        public MouseControlsViewModelTest()
        {
            _mouseControlsViewModelWithFlagsCleared = new MouseControlsViewModel()
            {
                IsAltFlagChecked = false,
                IsCtrlFlagChecked = false,
                IsShiftFlagChecked = false
            };

            _mouseControlsViewModelWithFlagsSet = new MouseControlsViewModel()
            {
                IsAltFlagChecked = true,
                IsCtrlFlagChecked = true,
                IsShiftFlagChecked = true
            };
        }

        [Fact]
        public void Given_IsAltFlagCheckedFalse_When_CheckedOn_Then_True()
        {
            // Arrange.
            var mouseControlsViewModel = _mouseControlsViewModelWithFlagsCleared;

            // Act.
            mouseControlsViewModel.IsAltFlagChecked = true;

            // Assert.
            Assert.True(mouseControlsViewModel.IsAltFlagChecked);
            Assert.False(mouseControlsViewModel.IsCtrlFlagChecked);
            Assert.False(mouseControlsViewModel.IsShiftFlagChecked);
        }

        [Fact]
        public void Given_IsAltFlagCheckedTrue_When_CheckedOff_Then_False()
        {
            // Arrange.
            var mouseControlsViewModel = _mouseControlsViewModelWithFlagsSet;

            // Act.
            mouseControlsViewModel.IsAltFlagChecked = false;

            // Assert.

            Assert.False(mouseControlsViewModel.IsAltFlagChecked);
            Assert.True(mouseControlsViewModel.IsCtrlFlagChecked);
            Assert.True(mouseControlsViewModel.IsShiftFlagChecked);
        }

        [Fact]
        public void Given_IsCtrlFlagCheckedFalse_When_CheckedOn_Then_True()
        {
            // Arrange.
            var mouseControlsViewModel = _mouseControlsViewModelWithFlagsCleared;

            // Act.
            mouseControlsViewModel.IsCtrlFlagChecked = true;

            // Assert.
            Assert.False(mouseControlsViewModel.IsAltFlagChecked);
            Assert.True(mouseControlsViewModel.IsCtrlFlagChecked);
            Assert.False(mouseControlsViewModel.IsShiftFlagChecked);
        }

        [Fact]
        public void Given_IsCtrlFlagCheckedTrue_When_CheckedOff_Then_False()
        {
            // Arrange.
            var mouseControlsViewModel = _mouseControlsViewModelWithFlagsSet;

            // Act.
            mouseControlsViewModel.IsCtrlFlagChecked = false;

            // Assert.

            Assert.True(mouseControlsViewModel.IsAltFlagChecked);
            Assert.False(mouseControlsViewModel.IsCtrlFlagChecked);
            Assert.True(mouseControlsViewModel.IsShiftFlagChecked);
        }

        [Fact]
        public void Given_IsShiftFlagCheckedFalse_When_CheckedOn_Then_True()
        {
            // Arrange.
            var mouseControlsViewModel = _mouseControlsViewModelWithFlagsCleared;

            // Act.
            mouseControlsViewModel.IsShiftFlagChecked = true;

            // Assert.
            Assert.False(mouseControlsViewModel.IsAltFlagChecked);
            Assert.False(mouseControlsViewModel.IsCtrlFlagChecked);
            Assert.True(mouseControlsViewModel.IsShiftFlagChecked);
        }

        [Fact]
        public void Given_IsShiftFlagCheckedTrue_When_CheckedOff_Then_False()
        {
            // Arrange.
            var mouseControlsViewModel = _mouseControlsViewModelWithFlagsSet;

            // Act.
            mouseControlsViewModel.IsShiftFlagChecked = false;

            // Assert.

            Assert.True(mouseControlsViewModel.IsAltFlagChecked);
            Assert.True(mouseControlsViewModel.IsCtrlFlagChecked);
            Assert.False(mouseControlsViewModel.IsShiftFlagChecked);
        }

    }
}