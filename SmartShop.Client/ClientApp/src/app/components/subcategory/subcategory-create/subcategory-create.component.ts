import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { throwError } from 'rxjs';
import { CategoryModel } from '../../../models/data/category-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';
import { SubcategoryService } from '../../../services/data/subcategory.service';

@Component({
  selector: 'app-subcategory-create',
  templateUrl: './subcategory-create.component.html',
  styleUrls: ['./subcategory-create.component.css']
})
export class SubcategoryCreateComponent implements OnInit {
  categories: CategoryModel[] = [];
  subcategory: SubcategoryModel = {};
  constructor(
    private subcategoryService: SubcategoryService,
    private categoryService: CategoryService,
    private notifyService: NotifyService
  ) { }
  /*
   * Form submit handler
   *
   * */
  insert(f: NgForm) {
    console.log(this.subcategory);
    this.subcategoryService.create(this.subcategory)
      .subscribe(r => {
        this.notifyService.success("Data saved successfully", "DISMISS");
        f.form.reset({});
        f.form.markAsUntouched();
        f.form.markAsPristine();
      }, err => {
        this.notifyService.fail("Failed to load category data", "DISMISS");
        throwError(err.error || err);
      })
  }
  ngOnInit(): void {
    this.categoryService.get()
      .subscribe(r => {
        this.categories = r;
      }, err => {
        this.notifyService.fail("Failed to load category data", "DISMISS");
        throwError(err.error || err);
      });
  }

}
