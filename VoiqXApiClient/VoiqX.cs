using ManyHelpers.API;
using ManyHelpers.API.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using VoiqXApiClient.Models;

namespace VoiqXApiClient {
    public class VoiqX {
        private CosumingHelper _api;

        public event RequisitionEventHandler Requisition;
        public event ResponseEventHandler Response;

        public VoiqX(string baseAdress, string token) {
            if (!baseAdress.EndsWith("/")) {
                baseAdress = $"{baseAdress}/";
            }
            _api = new CosumingHelper(baseAdress)
                                .AddcontentType()
                                .AddBearerAuthentication(token);

            _api.Requisition += _api_Requisition;
            _api.Response += _api_Response;
        }

        public async Task<MailingCreationResponse> CreateMailingAsync(Mailing mailing) {
            var milingResponse = default(MailingCreationResponse);
            (MailingCreationResponse result, string statusCode, string message, HttpResponseHeaders header) = await _api.PostAsync<Mailing, MailingCreationResponse>("api/v1/oauth/mailing/create", mailing);

            if (result != null) {
                milingResponse = result;
            }

            return milingResponse;
        }

        public async Task<(MailingV2RootResponse result, string statusCode, string message, HttpResponseHeaders header)> CreateMailingV2Async(MailingV2 mailing) {
            var milingResponse = default(MailingV2RootResponse);
            return await _api.PostAsync<MailingV2, MailingV2RootResponse>("api/v2/oauth/mailings", mailing);

            //if (result != null) {
            //    milingResponse = result;
            //}

            //return milingResponse;
        }

        public async Task<(MailingV2RootResponse result, string statusCode, string message, HttpResponseHeaders header)> AddContatsMailingV2Async(MailingCustomerV2 mailingCostumers, int mailingId) {
            var milingResponse = default(MailingV2RootResponse);
            return await _api.PutAsync<MailingCustomerV2, MailingV2RootResponse>($"api/v2/oauth/mailings/{mailingId}/contacts", mailingCostumers);

            //if (result != null) {
            //    milingResponse = result;
            //}

            //return milingResponse;
        }
        public async Task<FullMaillingV2> GetMailingV2Async(int mailingId) {
            var milingResponse = default(FullMaillingV2);
            (FullMailingResponse result, string statusCode, string message, HttpResponseHeaders header) = await _api.GetAsync<FullMailingResponse>($"api/v2/oauth/mailings/{mailingId}");

            if (result != null) {
                milingResponse = result.mailing;
            }

            return milingResponse;
        }

        public async Task<StatusMailing> StatusMaillingAsync(int mailingId) {
            var campaignResponse = new StatusMailing();
            (StatusMailing result, string statusCode, string message, HttpResponseHeaders header) = await _api.GetAsync<StatusMailing>($"api/v1/oauth/mailing/{mailingId}/status");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public async Task<(CampaignCreationResponse result, string statusCode, string message, HttpResponseHeaders header)> CreateCampaignAsync(Campaign campaign) {
            var campaignResponse = default(CampaignCreationResponse);
            return await _api.PostAsync<Campaign, CampaignCreationResponse>("api/v1/oauth/messenger/campaign/create", campaign);

            //if (result != null) {
            //    campaignResponse = result;
            //}

            //return campaignResponse;
        }

        public async Task<CampaignsPhones> CampaignContactListAsync(int campaignId) {
            var campaignResponse = new CampaignsPhones();
            (CampaignsPhones result, string statusCode, string message, HttpResponseHeaders header) = await _api.GetAsync<CampaignsPhones>($"api/v1/oauth/messenger/{campaignId}/contacts/list");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public async Task<CampaignStartResponse> StartCampaignAsync(int campaignId) {
            var campaignResponse = default(CampaignStartResponse);
            (CampaignStartResponse result, string statusCode, string message, HttpResponseHeaders header) = await _api.PutAsync<int, CampaignStartResponse>($"api/v1/oauth/messenger/campaign/{campaignId}/start", campaignId);

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        public async Task<List<MailingCostumerStatus>> StatusCampaignAsync(int campaignId) {
            var campaignResponse = new List<MailingCostumerStatus>();
            (List<MailingCostumerStatus> result, string statusCode, string message, HttpResponseHeaders header) = await _api.GetAsync<List<MailingCostumerStatus>>($"api/v1/oauth/messenger/{campaignId}/details");

            if (result != null) {
                campaignResponse = result;
            }

            return campaignResponse;
        }

        private void _api_Requisition(object sender, RequisitionEventArgs e) {
            OnRequisition(sender, e);
        }

        private void _api_Response(object sender, ResponseEventArgs e) {
            OnResponse(sender, e);
        }


        private void OnRequisition(object sender, RequisitionEventArgs e) {
            Requisition?.Invoke(sender, e);
        }

        private void OnResponse(object sender, ResponseEventArgs e) {
            Response?.Invoke(sender, e);
        }
    }
}
