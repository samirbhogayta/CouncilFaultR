using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouncilFaultReport.Models
{
    public class Permit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string id { get; set; }
        public string permit_number { get; set; }
        public int customer_id { get; set; }
        public DateTime permit_valid_from { get; set; }
        public DateTime permit_valid_until { get; set; }
        public DateTime permit_issue_date { get; set; }
        public DateTime permit_cancel_date { get; set; }
        public string name_title { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string postcode { get; set; }
        public string organisation_or_charity { get; set; }
        public string property_name_or_number { get; set; }
        public string address_line { get; set; }
        public string street_name { get; set; }
        public string town { get; set; }
        public string zone { get; set; }
        public string country { get; set; }
        public string telephone { get; set; }
        public string authorisation_status { get; set; }
        public string authorisation_status_note { get; set; }
        public byte is_tnc_accepted { get; set; }
        public string permit_type { get; set; }
        public string extra { get; set; }
        public int address_id { get; set; }
        public decimal amount { get; set; }
        public DateTime year { get; set; }
        public int permit_period_id { get; set; }
        public string vrn { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string color { get; set; }
        public string cc { get; set; }
        public string co2 { get; set; }
        public string tier { get; set; }
        public decimal payment_amount { get; set; }
        public string payment_type { get; set; }
        public DateTime payment_date { get; set; }
        public string payment_cheque_number { get; set; }
        public string payment_cheque_short_code { get; set; }
        public string payment_cheque_cc_name { get; set; }
        public string payment_bacs_payment_ref { get; set; }
        public string payment_cc_payment_last_4_digit { get; set; }
        public string payment_card_expiry_date { get; set; }
        public string payment_cc_payment_ref_number { get; set; }
        public string payment_postal_order_number { get; set; }
        public string payment_page_note { get; set; }
        public byte no_of_times_change_of_registration_done { get; set; }
        public byte no_of_times_change_of_courtesy_car_done { get; set; }
        public byte is_permit { get; set; }
        public byte is_renewed { get; set; }
        public decimal refund_amount { get; set; }
        public string refund_type { get; set; }
        public DateTime refund_date { get; set; }
        public string refund_cheque_number { get; set; }
        public string refund_cheque_short_code { get; set; }
        public string refund_cheque_cc_name { get; set; }
        public string refund_bacs_payment_ref { get; set; }
        public string refund_cc_payment_last_4_digit { get; set; }
        public string refund_card_expiry_date { get; set; }
        public string refund_cc_payment_ref_number { get; set; }
        public string refund_postal_order_number { get; set; }
        public string refund_page_note { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
    }
}