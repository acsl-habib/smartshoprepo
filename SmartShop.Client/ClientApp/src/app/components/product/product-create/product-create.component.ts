import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { CategoryModel } from '../../../models/data/category-model';
import { ProductModel } from '../../../models/data/product-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';
import { ProductService } from '../../../services/data/product.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  //model
  product: ProductModel = {};
  // form select list
  categories: CategoryModel[] = [];
  subCategories: SubcategoryModel[] = [];
  //form
  productForm: FormGroup = new FormGroup({

    productName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    productDescription: new FormControl('', Validators.required),
    productPrice: new FormControl('', Validators.required),
   
    brandId: new FormControl('', Validators.required),
    categoryId: new FormControl(''),
    subcategoryId: new FormControl('', Validators.required)
    
  });
  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private notifyService: NotifyService
  ) { }
  get productCreated(): boolean {
    return this.product.productId != null;
  }
  /*
   * Handlers
   * 
   * */
  categoryChanged(event: any) {
    console.log(event.value);
    if (event.value !== '') {
      let id: number = Number(event.value);
      this.categoryService.getSubcategories(id)
        .subscribe(x => {
          this.subCategories = x;
        }, err => {
          this.notifyService.fail("Falied to load sub-categories", "DISMISS");
        });
    }
    else {
      this.subCategories = [];
    }
  }
  ngOnInit(): void {
    console.log(this.productCreated);
    this.categoryService.get()
      .subscribe(r => {
        this.categories = r;
      }, err => {
        this.notifyService.fail("Falied to load categories", "DISMISS");
      })
  }

}
