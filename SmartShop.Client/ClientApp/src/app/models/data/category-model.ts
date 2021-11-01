import { SubcategoryModel } from "./subcategory-model";

export interface CategoryModel {
 
 categoryId?: number;
  categoryName?: string;
  subcategories?: SubcategoryModel[]
}
