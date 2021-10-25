import { DiscountAmountType, DiscountRuleType } from "../constants/enum-data";

export interface CampaignModel {

  campaignId?: number;
  campaignName?: string;
  isActive?: boolean;
  startDate?: Date ;
  endDate?: Date ;
  discountType?: DiscountAmountType;
  discountAmount?: number;
  perOrderValue?: number;
  ruleType?: DiscountRuleType;
  minOrderValue?: number;
  subcategoryId?: number;

}
