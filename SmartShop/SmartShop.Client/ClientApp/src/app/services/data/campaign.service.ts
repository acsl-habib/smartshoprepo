import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../../config/app-constants';
import { CampaignModel } from '../../models/data/campaign-model';

@Injectable({
  providedIn: 'root'
})
export class CampaignService {

  constructor(private http: HttpClient) { }
  get(): Observable<CampaignModel[]> {
    return this.http.get<CampaignModel[]>(`${AppConstants.apiUrl}/api/Campaigns`);
  }
  getById(id: number): Observable<CampaignModel> {
    return this.http.get<CampaignModel>(`${AppConstants.apiUrl}/api/Campaigns/${id}`);
  }
  create(data: CampaignModel): Observable<CampaignModel> {
    return this.http.post<CampaignModel>(`${AppConstants.apiUrl}/api/Campaigns`, data);
  }
  update(data: CampaignModel): Observable<any> {
    return this.http.put<any>(`${AppConstants.apiUrl}/api/Campaigns/${data.campaignId}`, data);
  }
  delete(id: number): Observable<CampaignModel> {
    return this.http.delete<CampaignModel>(`${AppConstants.apiUrl}/api/Campaigns/${id}`);
  }
}
