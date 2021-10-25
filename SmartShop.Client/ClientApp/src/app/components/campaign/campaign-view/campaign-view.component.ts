import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { throwError } from 'rxjs';
import { ConfirmDialogComponent } from '../../../dialogs/confirm-dialog/confirm-dialog.component';
import { DiscountAmountType, DiscountRuleType } from '../../../models/constants/enum-data';
import { CampaignModel } from '../../../models/data/campaign-model';
import { NotifyService } from '../../../services/common/notify.service';
import { CampaignService } from '../../../services/data/campaign.service';

@Component({
  selector: 'app-campaign-view',
  templateUrl: './campaign-view.component.html',
  styleUrls: ['./campaign-view.component.css']
})
export class CampaignViewComponent implements OnInit {

  campaigns: CampaignModel[] = [];
  //mat table vars
  dataSource: MatTableDataSource<CampaignModel> = new MatTableDataSource(this.campaigns);
  @ViewChild(MatSort, { static: false }) sort!: MatSort;
  @ViewChild(MatPaginator, { static: false }) paginator!: MatPaginator;
  columnList: string[] = ["campaignName", "startDate", "endDate", "discountType", "discountAmount",  "ruleType", "actions"];
  constructor(
    private campaignService: CampaignService,
    private notifyService: NotifyService,
    private matDialogRef: MatDialog
  ) { }
  /*
   * Methods
   *
   * */
  getDisCountTypeName(v: number) {
    return DiscountAmountType[v];
  }
  getDiscountRuleTypeName(v: number) {
    return DiscountRuleType[v];
  }
  getRuleValue(data: CampaignModel) {
    if (data) return data.ruleType == DiscountRuleType.NoRule ? 'No restriction' : `Min Order >= ${data.minOrderValue}`;
    else return null;
  }
  delete(item: CampaignModel) {
    this.matDialogRef.open(ConfirmDialogComponent, {
      width: '400px'
    }).afterClosed()
      .subscribe(r => {
        if (r) {
          this.campaignService.delete(Number(item.campaignId))
            .subscribe(c => {
              this.notifyService.success("Campaign deleted", "DISMISS");
              this.dataSource.data = this.dataSource.data.filter(x => x.campaignId != item.campaignId);
            }, err => {
              this.notifyService.fail("Failed to delete campaign", "DISMISS");
              throwError(err.error || err);
            })
        }
      })
  }
  ngOnInit(): void {
    this.campaignService.get()
      .subscribe(r => {

        this.campaigns = r;
        console.log(this.campaigns)
        this.dataSource.data = this.campaigns;
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }, err => {
        this.notifyService.fail("Failed to load campaign list", "DISMISS");
        throwError(err.error || err);
      });
  }

}

function ComfirmDeleteDialog(ComfirmDeleteDialog: any) {
    throw new Error('Function not implemented.');
}
