import { PriceInputModel } from "./price-input-model";

export interface ProductAndPriceInputModel {
  productId?: number;
  productName?: string;
  productDescription?: string;
  priceDeterminingProperty?: string;
  productStatus?: boolean;
  brandId?: number;
  subcategoryId?: number;
  priceInputModels?: PriceInputModel[]
}
