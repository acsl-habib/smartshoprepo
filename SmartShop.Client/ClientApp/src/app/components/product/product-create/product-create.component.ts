import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { throwError } from 'rxjs';
import { BrandModel } from '../../../models/data/brand-model';
import { CategoryModel } from '../../../models/data/category-model';
import { ProductAndPriceInputModel } from '../../../models/data/input/product-and-price-input-model';
import { ProductConfigurationInputModel } from '../../../models/data/input/product-configuration-input-model';
import { ProductModel } from '../../../models/data/product-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { BrandService } from '../../../services/data/brand.service';
import { CategoryService } from '../../../services/data/category.service';
import { ProductService } from '../../../services/data/product.service';
import { SubcategoryService } from '../../../services/data/subcategory.service';
import { AcceptValidator } from '@angular-material-components/file-input';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  //model
  product: ProductModel = {};
  //for auto complete
  propertyNames: string[] = [];
  specLabels: string[] = []
  // form select list
  categories: CategoryModel[] = [];
  subCategories: SubcategoryModel[] = [];
  brands: BrandModel[] = [];
 //Images
  files: File[] = [];
  uploadMessages: string[] = [];
  uploadCount = 0;
  isUploading = false;
  //control field
  priceChangeWithProperty: boolean = true;
  //form
  productForm: FormGroup = new FormGroup({

    productName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    productDescription: new FormControl('', Validators.required),
       
    brandId: new FormControl('', Validators.required),
    categoryId: new FormControl(''),
    subcategoryId: new FormControl('', Validators.required),
    priceDeterminingProperty: new FormControl({ value: '', disabled: !this.priceChangeWithProperty }, Validators.required),
    priceControlPropery: new FormControl(true),
    prices: new FormArray([])
    
  });
  productConfigForm: FormGroup = new FormGroup({
    productSpecs: new FormArray([])
  });
  imagesForm: FormGroup = new FormGroup({
    images: new FormControl(undefined, Validators.required)
  });
  //for price error
  //priceError = false;
  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private subategoryService: SubcategoryService,
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
  get priceError() {
    return this.prices.touched && !this.prices.value.length;
  }
  //specs
  get productSpecs() {
    return this.productConfigForm.controls.productSpecs as FormArray;
  }
  get fimg() {
    return this.imagesForm.controls;
  }
  get imagesLen() {
    return this.files.length;
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
  saveProduct() {
    //this.priceError = false;
    if (this.productForm.invalid) return;
    if (!this.prices.value.length) {
      console.log("Price required");
      //this.priceError = true;
      return;
    }
    let data: ProductAndPriceInputModel = {
      productName: this.productForm.value.productName,
      brandId: this.productForm.value.brandId,
      subcategoryId: this.productForm.value.subcategoryId,
      productStatus: true,
      priceDeterminingProperty: this.productForm.value.priceDeterminingProperty,
      productDescription: this.productForm.value.productDescription
    };
   
    data.priceInputModels = this.prices.value;
    console.log(data);
    this.productService.saveWithPrice(data)
      .subscribe(x => {
        this.notifyService.success("Product Saved", "DISMISS");
        this.product.productId = x.productId;
        this.productForm.markAsPristine();
        this.productForm.markAsUntouched();
        this.loadSpecLabels(<number>x.subcategoryId);
      }, err => {
        this.notifyService.fail("Falied to save product", "DISMISS");
        throwError(err.error || err);
      });
   
  }
  loadSpecLabels(id: number) {
    this.subategoryService.getSpecLabels(id)
      .subscribe(r => {
        this.specLabels = r;
        console.log(r);
      }, err => {
        this.notifyService.fail("Falied to save spec labels", "DISMISS");
        throwError(err.error || err);
      });
  }
  update() {
    
  }
  addMore() {
    this.product = {};
    this.productForm.reset({});
    console.log(this.productForm.value);
  }
  //product specs
  addSpec() {
    this.productSpecs.push(new FormGroup({
      label: new FormControl('', Validators.required),
      value: new FormControl('', Validators.required)
    }));
  }
  removeSpec(index: number) {
    this.productSpecs.removeAt(index);
  }
  saveConfig() {
    console.log(this.productConfigForm.value);
    let data: ProductConfigurationInputModel = {
      productId: this.product.productId,
      specs: this.productConfigForm.get('productSpecs')?.value
    };
    console.log(data);
    this.productService.saveSpecs(data)
      .subscribe(r => {
        this.notifyService.success("Product spec saved", "DISMISSS");
      }, err => {
        this.notifyService.fail("Falied to save product specs", "DISMISS");
        throwError(err.error || err);
      })
  }
  saveImages() {
    this.uploadMessages = [];
    this.isUploading = true;
    
    this.files.forEach((f, i) => {
      this.doSaveImages(i, f);
      
    });
    
  }
  doSaveImages(i: number, f: File) {
    const reader = new FileReader();

    reader.onload = (e: any) => {
      this.productService.uploadImage(<number>this.product.productId, f)
        .subscribe(res => {
          //console.log(res);
          this.uploadCount = 100 * (this.files.length / i)
          this.uploadMessages.push(`${f.name} uploaded`);
          this.checkUploadDone();

        }, err => {
          this.notifyService.fail("Falied to upload "+ f.name, "DISMISS");
          
          
          this.uploadMessages.push(`${f.name} upload failed`);
          throwError(err.error || err);
         
        })
    };

    reader.readAsArrayBuffer(f);
  }
  checkUploadDone() {
    if (this.uploadMessages.length == this.files.length) {
      this.isUploading = false;
      this.notifyService.success("Uploading done", "DISMISS");
      this.resetImages();
    }
  }
  resetImages() {
    
   
    this.imagesForm.reset({});
    this.files = [];
    this.uploadCount = 0;
    this.uploadMessages = [];
    //console.log(this.imagesLen)
  }

  
  /*
   * Lifecycle events
   *
   * */
  ngOnInit(): void {
    this.addSpec();
    //console.log(this.productCreated);
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
      });
    this.productService.getProptertyNames()
      .subscribe(r => {
        this.propertyNames = r;
      }, err => {
        this.notifyService.fail("Falied to load property autocomplete list", "DISMISS");
        throwError(err.error || err);
      });
    //console.log(this.prices.controls[0].get('propertyValue')?.errors?.required)
    
   
    this.fimg.images.valueChanges.subscribe((files: any) => {
      if (!Array.isArray(files)) {
        this.files = [files];
      } else {
        this.files = files;
      }
    });
    console.log(this.fimg.images.errors?.required);
  }

}
