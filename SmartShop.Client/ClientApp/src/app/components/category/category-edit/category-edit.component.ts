import { unsupported } from '@angular/compiler/src/render3/view/util';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, Validators } from '@angular/forms';
import { FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { CategoryModel } from '../../../models/data/category-model';
import { CategoryEditModel } from '../../../models/data/edit/category-edit-model';
import { SubcategoryEditModel } from '../../../models/data/edit/subcategory-edit-model';
import { SubcategoryModel } from '../../../models/data/subcategory-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';
import { SubcategoryService } from '../../../services/data/subcategory.service';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.css']
})
export class CategoryEditComponent implements OnInit {
  category: CategoryEditModel = {};
  //form
  categoryForm: FormGroup = new FormGroup({
    categoryName: new FormControl('', Validators.required),
    subcategories: new FormArray([])
  })
  constructor(
    private categoryService: CategoryService,
    private subcategoryService: SubcategoryService,
    private notifyService: NotifyService,
    private activatedRoute: ActivatedRoute
  ) { }
  /*
   * Properties
   *
   * */
  get f() {
    return this.categoryForm.controls;
  }
  get subcategories() {
    return this.categoryForm.controls.subcategories as FormArray;
  }
  /*
   * Methods
   *
   * */
  addSubcategory(data?: SubcategoryEditModel) {
    this.subcategories.push(
      new FormControl(data?.subcategoryName ?? '', Validators.required)
    );
  }
  removeSubcategory(index: number) {
    if (this.category) {
      if (index >= <number>this.category?.subcategories?.length) {
        this.subcategories.removeAt(index);
        return;
      }
      if (this.category.subcategories?.length && this.category.subcategories[index]) {
        if (<number>this.category?.subcategories[index]?.productCount > 0) {
          this.notifyService.fail("This item has related product.", "DISMISS");
          return;
        }
        else {
          this.subcategoryService.delete(<number>this.category?.subcategories[index]?.subcategoryId)
            .subscribe(r => {
              this.notifyService.success("Subcategory is deleted", "DISMISS");
              this.subcategories.removeAt(index);
              this.category.subcategories?.splice(index, 1);
            }, err => {
              this.notifyService.fail("Failed to delete subcategory", "DISMISS");
            });
        }
      }
    }
    
  }
  setFormControls() {
    this.f.categoryName.patchValue(this.category.categoryName);
    this.category.subcategories?.forEach(s => {
      this.addSubcategory(s);
    });
  }
  /*
   * Handlers
   *
   * */
  update(): void {
    this.categoryService.update(this.category)
      .subscribe(r => {

        this.notifyService.success("Succeeded to update", "DISMISS");
      }, err => {
        this.notifyService.fail("Failed to update", "DISMISS");
        throwError(err.error || err);
      });
  }
  updateSubcategory(index: number) {
    let subName = this.subcategories.controls[index].value;
    console.log(subName)
    if (this.category.subcategories?.length && this.category.subcategories[index]) {
      if (this.category?.subcategories[index]) {
        let sub = this.category?.subcategories[index];
        let data: SubcategoryModel = {
          subcategoryId: sub.subcategoryId,
          subcategoryName: sub.subcategoryName,
          categoryId: this.category.categoryId
        }
        console.log(data);
        this.subcategoryService.update(data)
          .subscribe(r => {
            this.notifyService.success("Suncceed to update", "DISMISS");
          }, err => {
            this.notifyService.fail("Failed to update", "DISMISS");
            throwError(err.error | err);
          });
      }
    }
    else {
      let data: SubcategoryModel = {
        subcategoryName: subName,
        categoryId: this.category.categoryId
      };
      console.log(data);
      this.subcategoryService.create(data)
        .subscribe(r => {
          this.notifyService.success("Succeed to create", "DISMISS");
        }, err => {
          this.notifyService.fail("Failed to carete", "DISMISS");
          throwError(err.error | err);
        });
    }
      
   
   
  }
  ngOnInit(): void {
    let id: number = this.activatedRoute.snapshot.params.id;
    this.categoryService.getByIdForEdit(id)
      .subscribe(r => {
        console.log(r);

        this.category = r;
        this.setFormControls();
        console.log(this.subcategories.controls[0].value);
      }, err => {
        this.notifyService.fail("Failed to load project", "DISMISS");
        throwError(err.error | err);
      });
  }


}
