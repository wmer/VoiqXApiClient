using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using VoiqXApiClient.Models;

namespace VoiqXApiClient {
    public class VoiqX {
        private ConsumerHelper _api;

        public VoiqX(string baseAdress, string token) {
            _api = new ConsumerHelper(baseAdress, token);
        }

        public MailingCreationResponse CreateMailing(Mailing mailing) {
            var milingResponse = default(MailingCreationResponse);
            (MailingCreationResponse result, string statusCode, string message) = _api.Post<Mailing, MailingCreationResponse>("api/v1/oauth/mailing/create", mailing);

            if (result != null) {
                milingResponse = result;
            }

            return milingResponse;
        }

        public MailingV2RootResponse CreateMailingV2(MailingV2 mailing) {
            var milingResponse = default(MailingV2RootResponse);
            (MailingV2RootResponse result, string statusCode, string message) = _api.Post<MailingV2, MailingV2RootResponse>("api/v2/oauth/mailings", mailing);

            if (result != null) {
                milingResponse = result;
            }

            return milingResponse;
        }

        public MailingV2RootResponse AddContatsMailingV2(MailingCustomerV2 mailingCostumers, int mailingId) {
            var milingResponse = default(MailingV2RootResponse);
            (MailingV2RootResponse result, string statusCode, string message) = _api.Put<MailingCustomerV2, MailingV2RootResponse>($"api/v2/oauth/mailings/{mailingId}/contacts", mailingCostumers);

            if (result != null) {
                milingResponse = result;
            }

            return milingResponse;
        }

        public StatusMailing StatusMailling(int mailingId) {
            var campaignResponse = new StatusMailing();
            (StatusMailing result, string statusCode, string message) = _api.Get<StatusMailing>($"api/v1/oauth/mailing/{mailingId}/status");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public CampaignCreationResponse CreateCampaign(Campaign campaign) {
            var campaignResponse = default(CampaignCreationResponse);
            (CampaignCreationResponse result, string statusCode, string message) = _api.Post<Campaign, CampaignCreationResponse>("api/v1/oauth/messenger/campaign/create", campaign);

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public CampaignsPhones CampaignContactList(int campaignId) {
            var campaignResponse = new CampaignsPhones();
            (CampaignsPhones result, string statusCode, string message) = _api.Get<CampaignsPhones>($"api/v1/oauth/messenger/{campaignId}/contacts/list");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public CampaignStartResponse StartCampaign(int campaignId) {
            var campaignResponse = default(CampaignStartResponse);
            (CampaignStartResponse result, string statusCode, string message) = _api.Put<int, CampaignStartResponse>($"api/v1/oauth/messenger/campaign/{campaignId}/start", campaignId);

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public List<MailingCostumerStatus> StatusCampaign(int campaignId) {
            var campaignResponse = new List<MailingCostumerStatus>();
            (List< MailingCostumerStatus> result, string statusCode, string message) = _api.Get<List<MailingCostumerStatus>>($"api/v1/oauth/messenger/{campaignId}/details");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }
    }
}
