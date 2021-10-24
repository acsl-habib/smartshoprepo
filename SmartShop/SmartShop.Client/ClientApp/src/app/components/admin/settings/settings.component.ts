import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { throwError } from 'rxjs';
import { NotifyService } from 'src/app/services/common/notify.service';
import { DbUtilityService } from 'src/app/services/data/db/db-utility.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

  isDbCreated!:boolean;
  constructor(
    private dbUtilService:DbUtilityService,
    private notifyService:NotifyService
  ) { }
  initDb(){
    this.dbUtilService.initDb()
    .subscribe(
      r=>{
        console.log(r);
        this.isDbCreated = true;
        this.notifyService.success("Database created", "DISMISS");
      }, err=>{
        this.notifyService.fail("Failed to create database", "DISMISS");
      }

    )

  }
  ngOnInit(): void {
    this.dbUtilService.getDbStatus()
    .subscribe(
      r=> this.isDbCreated = r,
      err=>{
        this.isDbCreated=true;
        this.notifyService.fail("Cannot load database status", "DISMISS");
      }
    )
  }

}
