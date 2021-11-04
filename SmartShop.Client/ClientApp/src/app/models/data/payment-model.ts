export class PaymentModel {
  constructor(
    public paymentId?: number,
    public paymentName?: string,
    public shortName?: string,
    public paymentType?: string,
    public accountNo?:string
  ) { }
}
