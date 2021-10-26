import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormControl, FormGroup } from '@angular/forms';
import { throwError } from 'rxjs';
import { CategoryModel } from '../../../models/data/category-model';
import { ProductConfiguration } from '../../../models/data/product-configuration';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';
import { ProductConfigService } from '../../../services/data/product-config.service';

@Component({
  selector: 'app-config-label',
  templateUrl: './config-label.component.html',
  styleUrls: ['./config-label.component.css']
})
export class ConfigLabelComponent implements OnInit {
  //model
  configLabel: ProductConfiguration = {};
  //select list
  categories: CategoryModel[] = [];
  subCategories: SubcategoryModel[] = [];
  //form
  configForm: FormGroup = new FormGroup({
    configurationLabel: new FormControl('', Validators.required),
    categoryId: new FormControl(''),
    subcategoryId: new FormControl('', Validators.required)
  });
  constructor(
    private productConfigService: ProductConfigService,
    private categoryService: CategoryService,
    private notifyService: NotifyService
  ) { }
  get f() {
    return this.configForm.controls;
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
  ngOnInit(): void {
    this.categoryService.get()
      .subscribe(r => {
        this.categories = r;
      }, err => {
        this.notifyService.fail("Falied to load categories", "DISMISS");
        throwError(err.error || err);
      });
  }

}
