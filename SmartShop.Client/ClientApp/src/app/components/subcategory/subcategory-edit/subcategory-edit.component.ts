import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { CategoryModel } from '../../../models/data/category-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';
import { SubcategoryService } from '../../../services/data/subcategory.service';

@Component({
  selector: 'app-subcategory-edit',
  templateUrl: './subcategory-edit.component.html',
  styleUrls: ['./subcategory-edit.component.css']
})
export class SubcategoryEditComponent implements OnInit {

  categories: CategoryModel[] = [];
  subcategory!: SubcategoryModel;
  constructor(
    private subcategoryService: SubcategoryService,
    private categoryService: CategoryService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }
  /*
   * Form submit handler
   *
   * */
  update(f: NgForm) {
    console.log(this.subcategory)
    this.subcategoryService.update(this.subcategory)
      .subscribe(r => {
        this.notifyService.success("Data updated successfully", "DISMISS");
      
        f.form.markAsUntouched();
        f.form.markAsPristine();
      }, err => {
        this.notifyService.fail("Failed to load category data", "DISMISS");
        throwError(err.error || err);
      })
  }
  ngOnInit(): void {
    
    let id: number = this.activatedRoute.snapshot.params.id;
    this.subcategoryService.getById(id)
      .subscribe(
        r => {
          this.subcategory = r;
        },
        err => {
          this.notifyService.fail("Failed to load sub-category data", "DISMISS");
          throwError(err.error || err);
        })
    this.categoryService.get()
      .subscribe(r => {
        this.categories = r;
      }, err => {
        this.notifyService.fail("Failed to load category data", "DISMISS");
        throwError(err.error || err);
      });
  }

}
