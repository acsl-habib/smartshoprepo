import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { AppConstants } from '../../../config/app-constants';
import { BrandModel } from '../../../models/data/brand-model';
import { CategoryModel } from '../../../models/data/category-model';
import { ProductEditModel } from '../../../models/data/edit/product-edit-model';
import { ProductImageEditModel } from '../../../models/data/edit/product-image-edit-model';
import { ProductPriceEditModel } from '../../../models/data/edit/product-price-edit-model';
import { ProductSpecEditModel } from '../../../models/data/edit/product-spec-edit-model';
import { ProductImageModel } from '../../../models/data/product-image-model';
import { ProductModel } from '../../../models/data/product-model';
import { ProductPriceModel } from '../../../models/data/product-price-model';
import { ProductSpecModel } from '../../../models/data/product-spec-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { ImagePathResponse } from '../../../models/data/viewmodels/image-path-response';
import { NotifyService } from '../../../services/common/notify.service';
import { BrandService } from '../../../services/data/brand.service';
import { CategoryService } from '../../../services/data/category.service';
import { ProductService } from '../../../services/data/product.service';
import { SubcategoryService } from '../../../services/data/subcategory.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  product: ProductEditModel = {};
  //for auto complete
  propertyNames: string[] = [];
  specLabels: string[] = []
  // form select list
  categories: CategoryModel[] = [];
  subCategories: SubcategoryModel[] = [];
  brands: BrandModel[] = [];
  //images
  imagePath = `${AppConstants.apiUrl}/Images/`;
  files: File[] = [];
  uploadMessages: string[] = [];
  uploadCount = 0;
  isUploading = false;
  productImages: ProductImageEditModel[] = [];
  responses: ImagePathResponse[] =[]

  productForm: FormGroup = new FormGroup({

    productName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    productDescription: new FormControl('', Validators.required),

    brandId: new FormControl('', Validators.required),
    categoryId: new FormControl(''),
    subcategoryId: new FormControl('', Validators.required),
    priceDeterminingProperty: new FormControl('', Validators.required),
    
    prices: new FormArray([])

  });
  productConfigForm: FormGroup = new FormGroup({
    productSpecs: new FormArray([])
  });
  imagesForm: FormGroup = new FormGroup({
    images: new FormControl(undefined, Validators.required)
  });
  constructor(
    private productService: ProductService,
    private brandService: BrandService,
    private categoryService: CategoryService,
    private subcategoryService: SubcategoryService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }
  get f() {
    return this.productForm.controls;
  }
  get prices() {
    return this.productForm.controls.prices as FormArray;
  }
  //image
  get fimg() {
    return this.imagesForm.controls;
  }
  get imagesLen() {
    return this.files.length;
  }
  //specs
  //specs
  get productSpecs() {
    return this.productConfigForm.controls.productSpecs as FormArray;
  }
  /*
   * Methods
   *
   * */
  loadSubCategory(id: number) {
    this.categoryService.getSubcategories(id)
      .subscribe(x => {
        this.subCategories = x;
      }, err => {
        this.notifyService.fail("Falied to load sub-categories", "DISMISS");
        throwError(err.error || err);
      });
  }
  loadSpecLabels(id: number) {
    this.subcategoryService.getSpecLabels(id)
      .subscribe(r => {
        this.specLabels = r;
        console.log(r);
      }, err => {
        this.notifyService.fail("Falied to save spec labels", "DISMISS");
        throwError(err.error || err);
      });
  }
  //price
  addPrice(data?: ProductPriceEditModel) {
    this.prices.push(new FormGroup({
      propertyValue: new FormControl(data?.propertyValue ?? '', Validators.required),
      price: new FormControl(data?.price ?? undefined, Validators.required)
    }));
  }
  removeImage(index: number) {
    let img: ProductImageEditModel | undefined = this.product?.productImages?.length ? this.product?.productImages[index] : undefined;
    if (img) {

      this.productService.deleteProductImage(<number>img.productImageId)
        .subscribe(r => {
          this.notifyService.success("Product image deleted", "DISMISS");
          this.product?.productImages?.splice(index, 1);
        }, err => {
          this.notifyService.fail("Falied to delete product image", "DISMISS");
          throwError(err.error || err);
        });
    }
  }
  //images
  removeSpec(index: number) {
    let spec: ProductSpecModel | undefined = this.product?.productSpecs?.length ? this.product?.productSpecs[index] : undefined;
    if (spec) {

      this.productService.deleteProductSpec(<number>spec.productSpecId)
        .subscribe(r => {
          this.notifyService.success("Product spec deleted", "DISMISS");
          this.product?.productSpecs?.splice(index, 1);
          this.productSpecs.removeAt(index);
        }, err => {
          this.notifyService.fail("Falied to delete product spec", "DISMISS");
          throwError(err.error || err);
        });
    }
  }
  addSpec(spec?: ProductSpecEditModel) {
    this.productSpecs.push(new FormGroup({
      label: new FormControl(spec?.label ?? '', Validators.required),
      value: new FormControl(spec?.value ?? '', Validators.required)
    }));
  }
  removePrice(index: number) {
    if (this.prices.controls.length < 2) {

      this.notifyService.fail("Product must have on price", "DISMISS");
      return;
    }
    if (index > <number>this.product.productPrices?.length - 1) {
      this.prices.removeAt(index);
    }
    else {
      let p: ProductPriceEditModel | undefined = this.product?.productPrices?.length ? this.product?.productPrices[index] : undefined;

      if (p) {
        console.log(p);
        this.productService.deleteProductPrice(<number>p.productPriceId)
          .subscribe(r => {
            this.notifyService.success("Product price deleted", "DISMISS");
            this.product.productPrices?.splice(index, 1);
            this.prices.removeAt(index);
          }, err => {
            this.notifyService.fail("Failed to delete product price", "DISMISS");
            throwError(err.error || err);
          });
      }
    }
    
  }
  saveSpec(index: number) {
    if (index > <number>this.product.productSpecs?.length - 1) {
      //new
      let data: ProductSpecModel = {
        
        productId: this.product.productId,
        label: this.productSpecs.controls[index].get('label')?.value,
        value: this.productSpecs.controls[index].get('value')?.value
      };
      this.productService.saveProductSpec(data)
        .subscribe(r => {
          this.product.productSpecs?.push(r);
          this.notifyService.success("Product spec saved", "DISMISS");
        }, err => {
          this.notifyService.fail("Falied to update product spec", "DISMISS");
          throwError(err.error || err);
        });
    }
    else {
      //existing
      let spec: ProductSpecEditModel | undefined = this.product.productSpecs?.length ? this.product.productSpecs[index] : undefined;
      if (spec) {
        let data: ProductSpecModel = {
          productSpecId: spec.productSpecId,
          productId: this.product.productId,
          label: this.productSpecs.controls[index].get('label')?.value,
          value: this.productSpecs.controls[index].get('value')?.value
        };
        console.log(data);
        this.productService.updateProductSpec(data)
          .subscribe(r => {
            if (this.product?.productSpecs?.length) {
              this.product.productSpecs[index].label = data.label;
              this.product.productSpecs[index].value = data.value;
            }
            this.notifyService.success("Product spec update", "DISMISS");
          }, err => {
            this.notifyService.fail("Falied to update product spec", "DISMISS");
            throwError(err.error || err);
          });
      }
    }
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
  }

  saveProduct() {
    let data: ProductModel = {
      productId: this.product.productId,
      productName: this.f.productName.value,
      brandId: this.f.brandId.value,
      subcategoryId: this.f.subcategoryId.value,
      productStatus: true,
      productDescription: this.f.productDescription.value,
      priceDeterminingProperty: this.f.priceDeterminingProperty.value,

    };
    this.productService.update(data)
      .subscribe(r => {
        this.notifyService.success("Product data updated", "DISMISS");
      }, err => {
        this.notifyService.fail("Falied to update product", "DISMISS");
        throwError(err.error || err);
      });
  }
  savePrice(index: number) {
    console.log(index);
    let len = this.product?.productPrices?.length;
    if (index > Number(len) - 1) {
      let data: ProductPriceModel = {

        productId: this.product.productId,
        propertyValue: this.prices.controls[index].get('propertyValue')?.value,
        price: this.prices.controls[index].get('price')?.value
      };
      this.productService.saveProductPrice(data)
        .subscribe(r => {
          this.product.productPrices?.push({
            productId: r.productId,
            productPriceId: r.productPriceId,
            propertyValue: r.propertyValue,
            price: r.price
          });
        }, err => {
          this.notifyService.fail("Falied to save product price", "DISMISS");
          throwError(err.error || err);
        })
    }
    else {
      let p = this.product?.productPrices?.length ? this.product?.productPrices[index] : undefined;
      if (p) {
        let data: ProductPriceModel = {
          productPriceId: p.productPriceId,
          productId: this.product.productId,
          propertyValue: this.prices.controls[index].get('propertyValue')?.value,
          price: this.prices.controls[index].get('price')?.value
        };
        console.log(data);
        this.productService.updateProductPrice(data)
          .subscribe(r => {
            this.notifyService.success("Product price updated", "DISMISS");
          }, err => {
            this.notifyService.fail("Falied to update price", "DISMISS");
            throwError(err.error || err);
          });
      }
    }
    
  }
  saveImages() {
    this.uploadMessages = [];
    this.isUploading = true;

    this.files.forEach((f, i) => {
      this.doSaveImages(i, f);

    });

  }
  doSaveImages(i: number, f: File) {
    console.log(i);
    const reader = new FileReader();

    reader.onload = (e: any) => {
      this.productService.uploadImage(<number>this.product.productId, f)
        .subscribe(res => {
          console.log(res.productImageId);
          console.log(res);
          this.uploadCount = 100 * (this.files.length / i)
          this.uploadMessages.push(`${f.name} uploaded`);
          this.responses.push(res);
          this.product.productImages?.push({
            productImageId: res.productImageId,
            imageName: res.imagePath,
            productId: this.product.productId
          });
          this.checkUploadDone();
          console.log(this.product.productImages);
        }, err => {
          this.notifyService.fail("Falied to upload " + f.name, "DISMISS");


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
      this.files.forEach(x => {})
    }
  }
  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.productService.getByIdForEdit(id)
      .subscribe(r => {
        this.product = r;
        console.log(this.product);
        this.loadSpecLabels(<number>this.product.productId);
        this.productForm.patchValue(this.product);
        this.product.productPrices?.forEach(p => {
          this.addPrice(p);
        });
        this.product.productSpecs?.forEach(sp => {
          this.addSpec(sp);
        });
        this.productImages = this.product?.productImages ?? [];
        if (this.product.priceDeterminingProperty == "None") {
          this.productForm.controls.priceDeterminingProperty.disable();
          this.prices.controls[0].get('propertyValue')?.disable();
        }
      }, err => {
        this.notifyService.fail("Failed to load product", "DISMISS");
      });
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
    this.subcategoryService.get()
      .subscribe(r => {
        this.subCategories = r;
      }, err => {
        this.notifyService.fail("Falied to load sub categories", "DISMISS");
        throwError(err.error || err);
      });
    this.fimg.images.valueChanges.subscribe((files: any) => {
      if (!Array.isArray(files)) {
        this.files = [files];
      } else {
        this.files = files;
      }
    });
  }

}
