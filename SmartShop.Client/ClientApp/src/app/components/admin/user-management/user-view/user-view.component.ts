import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { UserDataModel } from '../../../../models/data/user-data-model';
import { NotifyService } from '../../../../services/common/notify.service';
import { UserDataService } from '../../../../services/data/user-data.service';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {
  users: UserDataModel[] = [];
  //mat table vars
  dataSource: MatTableDataSource<UserDataModel> = new MatTableDataSource(this.users);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["username", "email", "roles"];
  constructor(
    private userDataService: UserDataService,
    private notifyService: NotifyService
  ) { }
  /*
   * Methods
   *
   * */
  getRoleString(roles: string[]) {
    return roles.join(", ");
  }
  ngOnInit(): void {
    this.userDataService.get()
      .subscribe(r => {
       
        this.users = r;
        console.log(this.users);
        this.dataSource.data = this.users;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }, err => {
        this.notifyService.fail("Failed to load user list", "DISMISS");
        throwError(err.error || err);
      })
  }

}
