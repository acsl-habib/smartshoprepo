export class GlobalErrorHandler {
  handleError(error: any) {
    console.log(error);
    //console.error(error.statusText || error.message || error.toString());
  }
}
