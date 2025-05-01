using Xunit;

using MouseControls.ViewModels;

namespace MouseControls.Tests
{
    public class MouseControlsViewModelTest
    {
        [Fact]
        public void Given_IsCtrlFlagCheckedFalse_When_CheckedOn_Then_True()
        {
            // Arrange.
            var mouseControlsViewModel = new MouseControlsViewModel();
            mouseControlsViewModel.IsCtrlFlagChecked = false;

            // Act.
            mouseControlsViewModel.IsCtrlFlagChecked = true;

            // Assert.
            Assert.True(mouseControlsViewModel.IsCtrlFlagChecked);
        }

        [Fact]
        public void Given_IsCtrlFlagCheckedTrue_When_CheckedOff_Then_False()
        {
            // Arrange.
            var mouseControlsViewModel = new MouseControlsViewModel();
            mouseControlsViewModel.IsCtrlFlagChecked = true;

            // Act.
            mouseControlsViewModel.IsCtrlFlagChecked = false;

            // Assert.
            Assert.False(mouseControlsViewModel.IsCtrlFlagChecked);
        }

    }
}