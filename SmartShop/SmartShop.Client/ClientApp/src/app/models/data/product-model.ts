import { ColorModel } from "./color-model";
import { SizeModel } from "./size-model";

export interface ProductModel {
  productId?: number,
  productName?: string,
  productDescription?: string,
  productPrice?: number,
  productImage?: string,
  brandId?: number,
  subcategoryId?: number,
  productColors?: ColorModel[],
  prudctSizes?: SizeModel[]
}
