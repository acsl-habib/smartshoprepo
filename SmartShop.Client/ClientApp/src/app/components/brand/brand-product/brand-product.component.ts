import { DecimalPipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
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
  selector: 'app-brand-product',
  templateUrl: './brand-product.component.html',
  styleUrls: ['./brand-product.component.css']
})
export class BrandProductComponent implements OnInit {
  products: ProductModel[] = [];
 
  //table
  dataSource: MatTableDataSource<ProductModel> = new MatTableDataSource(this.products);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["productName", "productDescription"]
 
   
  constructor(
    private productService: ProductService,
    private brandService: BrandService,
    private notifyService: NotifyService,
    private decimalPipe: DecimalPipe,
    private activatedRoute: ActivatedRoute
  ) { }
  /*
   * Methods
   *
   * */
  

  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    console.log(id)
    this.brandService.getProducts(id)
      .subscribe(x => {
        this.products = x;
        
        this.dataSource.data = this.products;
        console.log(this.dataSource.data);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
        
      }, err => {
        this.notifyService.fail("Failed to load products", "DISMISS");
        throwError(err.error || err);
      });
  }

}
