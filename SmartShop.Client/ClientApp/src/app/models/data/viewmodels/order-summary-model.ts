import { OrderStatus } from "../../constants/enum-data";
import { CustomerModel } from "../customer-model";
import { OrderDetailModel } from "../order-detail-model";

export interface OrderSummaryModel {
  orderId?: number;
  orderDate?: Date;
  deliveryDate?: Date;
  customerId?: number;
  shippingId?: number;
  trxId?: string;
  paymentName?: string;
  isConfirmed?: boolean;
  orderStatus?: OrderStatus;
  comment?: string;
  orderDetails?: OrderDetailModel[],
  customer?: CustomerModel;

}
