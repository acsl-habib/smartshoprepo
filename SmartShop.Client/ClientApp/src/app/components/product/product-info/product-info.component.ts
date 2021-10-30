import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { AppConstants } from '../../../config/app-constants';
import { ProductModel } from '../../../models/data/product-model';
import { NotifyService } from '../../../services/common/notify.service';
import { ProductService } from '../../../services/data/product.service';

@Component({
  selector: 'app-product-info',
  templateUrl: './product-info.component.html',
  styleUrls: ['./product-info.component.css']
})
export class ProductInfoComponent implements OnInit {
  product: ProductModel = {};
  imagePath: string = AppConstants.apiUrl + '/Images';
  imageObject: any[] = [];
  constructor(
    private productService: ProductService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute,
    private cd: ChangeDetectorRef
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
  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.productService.getIncludeById(id)
      .subscribe(x => {
        this.product = x;
        this.createImageObject();
      }, err => {
        this.notifyService.fail("Failed to load product", "DISMISS");
        throwError(err.error || err);
      })
  }
}
