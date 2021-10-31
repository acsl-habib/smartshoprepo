import { DecimalPipe } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { AppConstants } from '../../../config/app-constants';
import { BrandModel } from '../../../models/data/brand-model';
import { ProductModel } from '../../../models/data/product-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { BrandService } from '../../../services/data/brand.service';
import { ProductService } from '../../../services/data/product.service';
import { SubcategoryService } from '../../../services/data/subcategory.service';

@Component({
  selector: 'app-product-info',
  templateUrl: './product-info.component.html',
  styleUrls: ['./product-info.component.css']
})
export class ProductInfoComponent implements OnInit {
  product: ProductModel = {};
  brands: BrandModel[] = [];
  subcategories: SubcategoryModel[] = [];
  imagePath: string = AppConstants.apiUrl + '/Images';
  imageObject: any[] = [];
  constructor(
    private productService: ProductService,
    private brandService: BrandService,
    private subcategoryService:SubcategoryService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute,
    private cd: ChangeDetectorRef,
    private decimalPipe: DecimalPipe
  ) { }
  getImageName() {
    return this.product?.productImages ? this.product?.productImages[0].imageName : 'no-image.png'
  }
  createImageObject() {
    this.product.productImages?.forEach(img => {
      this.imageObject.push({
        image: `${this.imagePath}/${img.imageName}`,
        thumbImage: `${this.imagePath}/${img.imageName}`
      });
     
    })
  }
  getBrandName(id:any) {
    let brand = this.brands.find(x => x.brandId == id);
    return brand?.brandName;
  }
  getSubcategoryName(id: any) {
    let subcat = this.subcategories.find(x => x.subcategoryId == id);
    return subcat?.subcategoryName;
  }
  getPrice() {
    let priceStringArray = this.product.productPrices?.map(p => p.propertyValue == 'None' ? `${this.decimalPipe.transform(p.price, '1.2-2')}` : `${p.propertyValue}: ${this.decimalPipe.transform(p.price, '1.2-2')}`);
    return priceStringArray?.join(', ');
  }
  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.productService.getIncludeById(id)
      .subscribe(x => {
        this.product = x;
        console.log(this.product);
        this.createImageObject();
      }, err => {
        this.notifyService.fail("Failed to load product", "DISMISS");
        throwError(err.error || err);
      });
    this.brandService.get()
      .subscribe(r => {
        this.brands = r;
      }, err => {
        this.notifyService.fail("Failed to load brands", "DISMISS");
        throwError(err.error || err);
      });
    this.subcategoryService.get()
      .subscribe(r => {
        this.subcategories = r;
      }, err => {
        this.notifyService.fail("Failed to load sub-categories", "DISMISS");
        throwError(err.error || err);
      });
    
  }
}
