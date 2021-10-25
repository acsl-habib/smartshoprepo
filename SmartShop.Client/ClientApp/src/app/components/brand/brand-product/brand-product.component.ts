import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { ProductModel } from '../../../models/data/product-model';
import { NotifyService } from '../../../services/common/notify.service';
import { BrandService } from '../../../services/data/brand.service';

@Component({
  selector: 'app-brand-product',
  templateUrl: './brand-product.component.html',
  styleUrls: ['./brand-product.component.css']
})
export class BrandProductComponent implements OnInit {
  products: ProductModel[] = [];
  constructor(
    private brandService: BrandService,
    private notifyService: NotifyService,
    private actvatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let id: number = this.actvatedRoute.snapshot.params.id;
    this.brandService.getProducts(id)
      .subscribe(x => {
        this.products = x;
      }, err => {
        this.notifyService.fail("Failed to load products", "DISMISS");
        throwError(err.error || err);
      });
  }

}
