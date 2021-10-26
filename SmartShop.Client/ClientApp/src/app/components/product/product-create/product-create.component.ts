import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { throwError } from 'rxjs';
import { BrandModel } from '../../../models/data/brand-model';
import { CategoryModel } from '../../../models/data/category-model';
import { ProductModel } from '../../../models/data/product-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { BrandService } from '../../../services/data/brand.service';
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
  brands: BrandModel[] = [];
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
    private brandService: BrandService,
    private notifyService: NotifyService
  ) { }
  get productCreated(): boolean {
    return this.product.productId != null;
  }
  get f() {
    return this.productForm.controls;
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
          throwError(err.error || err);
        });
    }
    else {
      this.subCategories = [];
    }
  }
  save() {
    if (this.productForm.invalid) return;
    this.product.productName = this.f.productName.value;
    this.product.productDescription = this.f.productDescription.value;
    this.product.productPrice = this.f.productPrice.value;
    this.product.brandId = this.f.brandId.value;
    this.product.subcategoryId = this.f.subcategoryId.value;

    this.productService.save(this.product)
      .subscribe(r => {
        this.product = r;
        this.notifyService.success("Success: Product saved", "DISMISS");
        this.productForm.markAsUntouched();
        this.productForm.markAsPristine();
      }, err => {
        this.notifyService.fail("Falied to save product", "DISMISS");
        throwError(err.error || err);
      });
   
  }
  update() {
    if (this.productForm.invalid) return;
    this.product.productName = this.f.productName.value;
    this.product.productDescription = this.f.productDescription.value;
    this.product.productPrice = this.f.productPrice.value;
    this.product.brandId = this.f.brandId.value;
    this.product.subcategoryId = this.f.subcategoryId.value;
    this.productService.update(this.product)
      .subscribe(r => {
       
        this.notifyService.success("Success: Product updated", "DISMISS");
        this.productForm.markAsUntouched();
        this.productForm.markAsPristine();
      }, err => {
        this.notifyService.fail("Falied to update product", "DISMISS");
        throwError(err.error || err);
      });
  }
  addMore() {
    this.product = {};
    this.productForm.reset({});
    console.log(this.productForm.value);
  }
  /*
   * Lifecycle events
   *
   * */
  ngOnInit(): void {
    console.log(this.productCreated);
    this.categoryService.get()
      .subscribe(r => {
        this.categories = r;
      }, err => {
        this.notifyService.fail("Falied to load categories", "DISMISS");
        throwError(err.error || err);
      });
    this.brandService.get()
      .subscribe(r => {
        this.brands = r;
      }, err => {
        this.notifyService.fail("Falied to load brands", "DISMISS");
        throwError(err.error || err);
      })
  }

}
