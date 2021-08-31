# BlazorBSModal
Bootstrap Modal For Blazor Wasm

# Install
Install this package in client_side project packages with:
```
Install-Package BlazorBSModal -Version x.x
``` 
x.x is version of package for use last version see https://www.nuget.org/packages/BlazorBSModal

# How to use
add Bootstrap v4 css and js files in client_side _Host.cshml or index.html

help:https://getbootstrap.com/docs/4.0/getting-started/introduction/

then use:
```
<BlazorBSModal.BSModal CloseBtnText="Close" ModalTitle="modalTitle" @ref="Modal" OnCloseModal="closeModal" OnOpenModal="openModal">
            <ModalBodyContentHtml>
            //your Modal Body
            </ModalBodyContentHtml>
</BlazorBSModal.BSModal>
```
then define Modal Ref in your code for open and close Manual:
```
private BSModal Modal { get; set; }
```
then use:
```
Modal.Open();
Modal.Close();
```
Finally, you can use opening and closing events callback:
```
private void closeModal()
{
    Console.WriteLine("closeModal");
}
private void openModal()
{
    Console.WriteLine("openModal");
}
```
