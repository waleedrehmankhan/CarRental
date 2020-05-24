import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PrintingService {

  constructor() { }


  printContents(contents: string, title = "Ipay", landscape = false, styles = '') {
    const popupWin = window.open('', '_blank', 'top:0,left:0,height:100%,width:auto');
    popupWin.document.open();
    popupWin.document.write(`

          <html>
            <head>
              <title>${title}</title>
              <link
                href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
                rel="stylesheet"
                integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
                crossorigin="anonymous">
              <style type="text/css" media="print">
                  @page{
                    size: ${landscape ? 'landscape' : 'portriat'};
                  }
              </style>
      
            </head>
            <body onload="window.print();window.close()">
            <style>
              ${styles}
            </style>
            ${contents}
            </body>
        </html>

      `);
    popupWin.document.close();
  }
}
