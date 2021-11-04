import { CustomerModel } from "../../services/data/customer-model";
import { OrderStatus } from "../constants/enum-data";
import { OrderDetailModel } from "./order-detail-model";

export interface OrderModel {
  orderId?: number;
  orderDate?: Date;
  deliveryDate?: Date;
  customerId?: number;
  shippingId: number;
  trxId?: string;
  paymentName?: string;
  isConfirmed?: boolean;
  orderStatus?: OrderStatus;
  comment?: string;
  orderDetails?: OrderDetailModel[],
  customer?: CustomerModel;
}
