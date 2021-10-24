import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SizeModel } from 'src/app/models/data/size-model';
import { NotifyService } from 'src/app/services/common/notify.service';
import { SizeService } from 'src/app/services/data/size.service';

@Component({
  selector: 'app-size-create',
  templateUrl: './size-create.component.html',
  styleUrls: ['./size-create.component.css']
})
export class SizeCreateComponent implements OnInit {
  Size: SizeModel = {};
  constructor(
    private sizeService:SizeService,
    private notifyService:NotifyService,
  ) { }

  
  create(Form: NgForm): void{
    this.sizeService.createSize(this.Size)
    .subscribe( s=> {
      this.Size = {};
      Form.form.markAsUntouched();
      Form.form.reset({});
      this.notifyService.success("Succeeded to Create Size", "DISMISS");
    }, Error => {
      this.notifyService.fail("Failed to Create Size", "DISMISS");
    });
  }

  ngOnInit(): void {
  }

}
