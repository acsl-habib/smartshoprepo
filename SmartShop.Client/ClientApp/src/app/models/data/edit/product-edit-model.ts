import { ProductImageEditModel } from "./product-image-edit-model";
import { ProductPriceEditModel } from "./product-price-edit-model";
import { ProductSpecEditModel } from "./product-spec-edit-model";

export interface ProductEditModel {
  productId?: number;
  productName?: string;
  productDescription?: string;
  priceDeterminingProperty?: string;
  productStatus?: boolean;
  brandId?: number;
  categoryId?: number;
  subcategoryId?: number;
  productImages?: ProductImageEditModel[];
  productSpecs?: ProductSpecEditModel[];
  productPrices?: ProductPriceEditModel[];
}
