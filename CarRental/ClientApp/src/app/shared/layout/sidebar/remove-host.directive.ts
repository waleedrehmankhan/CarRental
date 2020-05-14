import { Directive, ElementRef } from '@angular/core';

// https://stackoverflow.com/a/35837189
// Code from stack overflow to remove the host element

@Directive({
  selector: '[remove-host]'
})
export class RemoveHostDirective {

  constructor(private el: ElementRef) {}

  ngOnInit() {
    var nativeElement: HTMLElement = this.el.nativeElement,
      parentElement: HTMLElement = nativeElement.parentElement;

    while (nativeElement.firstChild) {
      parentElement.insertBefore(nativeElement.firstChild, nativeElement);
    }

    parentElement.removeChild(nativeElement);
  }

}
