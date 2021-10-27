import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
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
  //control field
  priceChangeWithProperty: boolean = true;
  //form
  productForm: FormGroup = new FormGroup({

    productName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    productDescription: new FormControl('', Validators.required),
       
    brandId: new FormControl('', Validators.required),
    categoryId: new FormControl(''),
    subcategoryId: new FormControl('', Validators.required),
    priceDeterminingProperty: new FormControl('', Validators.required),
    priceControlPropery: new FormControl(true),
    prices: new FormArray([])
    
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
  get prices() {
    return this.productForm.controls.prices as FormArray;
  }
  /*
   * Handlers
   * 
   * */
  priceControlProperyChanged(event: any) {
    this.priceChangeWithProperty = event.checked;

    this.prices.clear();
    if (this.priceChangeWithProperty) {
      this.productForm.controls['priceDeterminingProperty'].patchValue('');
      this.addPrice();
    }
    else {
      this.productForm.controls['priceDeterminingProperty'].patchValue('None');
      this.addPriceDefault();
    }
  }
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
  /*
   * Methods
   *
   * */
  
  addPrice() {
    this.prices.push(new FormGroup({
      propertyValue: new FormControl('', Validators.required),
      price: new FormControl(undefined, Validators.required)
    }));
  }
  remove(index: number) {
    this.prices.removeAt(index);
  }
  addPriceDefault() {
    this.prices.push(new FormGroup({
      propertyValue: new FormControl('None', Validators.required),
      price: new FormControl(undefined, Validators.required)
    }));
  }
  save() {
    
   
  }
  update() {
    
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
    if (this.priceChangeWithProperty) this.addPrice();
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
    console.log(this.prices.controls)
  }

}
