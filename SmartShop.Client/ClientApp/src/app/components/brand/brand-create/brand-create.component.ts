import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BrandModel } from 'src/app/models/data/brand-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { BrandService } from 'src/app/services/data/brand.service';

@Component({
  selector: 'app-brand-create',
  templateUrl: './brand-create.component.html',
  styleUrls: ['./brand-create.component.css']
})
export class BrandCreateComponent implements OnInit {
  
  Brand: BrandModel = new BrandModel();
  constructor(
    private brandService:BrandService,
    private notifyService:NotifyService,
  ) { }

  
  create(Form: NgForm): void{
    this.brandService.create(this.Brand)
    .subscribe( s=> {
      this.Brand = new BrandModel();
      Form.form.markAsUntouched();
      Form.form.reset({});
      this.notifyService.success("Succeeded to Create Brand", "DISMISS");
    }, Error => {
      this.notifyService.fail("Failed to Create Brand", "DISMISS");
    });
  }

  ngOnInit(): void {
  }

}
