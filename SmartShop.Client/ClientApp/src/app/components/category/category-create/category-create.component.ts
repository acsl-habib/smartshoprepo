import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { NgForm } from '@angular/forms';
import { throwError } from 'rxjs';
import { CategoryModel } from '../../../models/data/category-model';
import { CategoryInputModel } from '../../../models/data/input/category-input-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CategoryService } from '../../../services/data/category.service';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {

  category: CategoryModel = {};

  categoryForm: FormGroup = new FormGroup({
    categoryName: new FormControl('', Validators.required),
    subcategories: new FormArray([])
  })
  constructor(
    private categoryService: CategoryService,
    private notifyService: NotifyService
  ) { }
  get f() {
    return this.categoryForm.controls;
  }
  get subcategories() {
    return this.categoryForm.controls.subcategories as FormArray;
  }
  addSubcategory() {
    this.subcategories.push(new FormControl('', Validators.required));
  }
  removeSubcategory(index: number) {
    this.subcategories.removeAt(index);
  }
  save(): void {
    console.log(this.categoryForm.value);
    console.log(this.subcategories.value)
    let data: CategoryInputModel =   {
      categoryName: this.categoryForm.value.categoryName,
      subcategories: this.subcategories.value
    };
    console.log(data);
    this.categoryService.craeteWithSubcategories(data)
      .subscribe(r => {
        this.category = {};
        this.categoryForm.markAsPristine();
        this.categoryForm.markAsUntouched();
        this.categoryForm.reset({});
        this.notifyService.success("Succeeded to save data", "DISMISS");
      }
        , err => {
          this.notifyService.fail("Failed to Create Category", "DISMISS");
          throwError(err.error || err);
        })
  }

  ngOnInit(): void {
    this.addSubcategory();
  }

}
