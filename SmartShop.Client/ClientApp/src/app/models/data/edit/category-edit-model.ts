import { SubcategoryEditModel } from "./subcategory-edit-model";

export interface CategoryEditModel {
  categoryId?: number
  categoryName?: string
  subcategories?: SubcategoryEditModel[]
}
