import { DecimalPipe } from '@angular/common';
import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
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
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {
  //Model
  products: ProductModel[] = [];
  //related
  brands: BrandModel[] = [];
  subcategories: SubcategoryModel[] = [];
  //table
  dataSource: MatTableDataSource<ProductModel> = new MatTableDataSource(this.products);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["pic", "productName","price","details", "actions"]
  //Image location
  imagePath: string = AppConstants.apiUrl;
  constructor(
    private productService: ProductService,
    private brandService: BrandService,
    private subcategoryService: SubcategoryService,
    private notifyService: NotifyService,
    private decimalPipe: DecimalPipe
  ) { }
  /*
   * Methods
   *
   * */
  getImage(data: ProductModel) {
    if (data.productImages?.length) {
      return this.imagePath + "/Images/"+data.productImages[0].imageName;
    }
    else {
      return this.imagePath + "/Images/no-image.png";
    }
  }
  getPrice(data: ProductModel) {
    let priceStringArray = data.productPrices?.map(p => p.propertyValue == 'None' ? `${this.decimalPipe.transform(p.price, '1.2-2')}` : `${p.propertyValue}: ${this.decimalPipe.transform(p.price, '1.2-2')}`);
    return priceStringArray?.join(', ');
  }
  ngOnInit(): void {
    this.productService.getInclude()
      .subscribe(r => {
        this.products = r;
        console.log(this.products);
        this.dataSource.data = this.products;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }, err => {
        this.notifyService.fail("Faled to load products", "DISMISS");
        throwError(err.error || err);
      })
  }

}
