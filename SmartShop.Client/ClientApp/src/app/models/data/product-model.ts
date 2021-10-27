import { ColorModel } from "./color-model";
import { ProductImageModel } from "./product-image-model";
import { ProductPriceModel } from "./product-price-model";
import { ProductSpecModel } from "./product-spec-model";
import { SizeModel } from "./size-model";

export interface ProductModel {
  productId?: number;
  productName?: string;
  productDescription?: string;
  productStatus?: boolean;
  priceDeterminingProperty?: string;
  brandId?: number;
  subcategoryId?: number;
  productImages?: ProductImageModel[];
  productSpecs?: ProductSpecModel[];
  productPrices?: ProductPriceModel[];
}
