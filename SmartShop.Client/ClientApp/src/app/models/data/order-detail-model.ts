import { ProductModel } from "./product-model";

export interface OrderDetailModel {
  orderDetailId?: number;
  orderId?: number;
  productId?: number;
  quantity?: number;
  productPrice?: number;
  product?: ProductModel;
}
