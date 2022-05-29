using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorBSModal
{
    public partial class BSModal
    {
        [Parameter] public string ModalTitle { get; set; }

        [Parameter] public string CloseBtnText { get; set; } = "Close";

        [Parameter] public string ModalDialogClass { get; set; }
        [Parameter] public string ModalContentClass { get; set; }
        [Parameter] public string ModalHeaderClass { get; set; }
        [Parameter] public string ModalBodyClass { get; set; }
        [Parameter] public string ModalFooterClass { get; set; }

        [Parameter] public bool DirectionRTL { get; set; }
        [Parameter] public bool FadeModal { get; set; }
        [Parameter] public bool CloseOnClickOutOfModal { get; set; }

        [Parameter] public FullScreenAvailability FullScreenAvailability { get; set; } = FullScreenAvailability.FullScreenOff;

        [Parameter] public RenderFragment ModalBodyContentHtml { get; set; }

        [Parameter] public RenderFragment ModalHeader { get; set; }

        [Parameter] public RenderFragment ModalFooter { get; set; }

        [Parameter] public RenderFragment ModalFooterHtmlWhitoutCloseBtn { get; set; }

        [Parameter] public EventCallback OnCloseModal { get; set; }

        [Parameter] public EventCallback OnOpenModal { get; set; }

        [Parameter] public bool ShowHeader { get; set; } = true;
        [Parameter] public bool ShowFooter { get; set; } = true;
        [Parameter] public bool ShowBackdrop { get; set; } = true;

        public Guid Guid = Guid.NewGuid();
        public string ModalDisplay = "none;";
        public string ModalClass = "";
        public string fullScreenAvailability = "";
        public bool Backdrop = false;
        public bool DisposeModal = false;

        protected override void OnInitialized()
        {
            switch (FullScreenAvailability)
            {
                case FullScreenAvailability.FullScreenOff:
                    fullScreenAvailability = "";
                    break;
                case FullScreenAvailability.FullScreen:
                    fullScreenAvailability = "modal-fullscreen";
                    break;
                case FullScreenAvailability.FullScreenSMDown:
                    fullScreenAvailability = "modal-fullscreen-sm-down";
                    break;
                case FullScreenAvailability.FullScreenMDDown:
                    fullScreenAvailability = "modal-fullscreen-md-down";
                    break;
                case FullScreenAvailability.FullScreenLGDown:
                    fullScreenAvailability = "modal-fullscreen-lg-down";
                    break;
                case FullScreenAvailability.FullScreenXLDown:
                    fullScreenAvailability = "modal-fullscreen-xl-down";
                    break;
                case FullScreenAvailability.FullScreenXXLDown:
                    fullScreenAvailability = "modal-fullscreen-xxl-down";
                    break;
                default:
                    fullScreenAvailability = "";
                    break;
            }
        }
        public async Task ClickOnOutOfModal()
        {
            if (CloseOnClickOutOfModal)
                await Close();
        }
        public async Task Open()
        {
            DisposeModal = false;
            ModalDisplay = "block";
            ModalClass = "show";
            Backdrop = true;
            StateHasChanged();
            await OnOpenModal.InvokeAsync();
        }

        public async Task Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            Backdrop = false;
            StateHasChanged();
            await OnCloseModal.InvokeAsync();
        }

        public async Task CloseAndDispose()
        {
            DisposeModal = true;
            ModalDisplay = "none";
            ModalClass = "";
            Backdrop = false;
            StateHasChanged();
            await OnCloseModal.InvokeAsync();
        }
    }
    public enum FullScreenAvailability
    {
        FullScreenOff,
        FullScreen,
        FullScreenSMDown,
        FullScreenMDDown,
        FullScreenLGDown,
        FullScreenXLDown,
        FullScreenXXLDown
    }
}