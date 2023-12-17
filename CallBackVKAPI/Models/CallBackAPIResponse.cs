using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace CallBackVKAPI.Models
{
    [Serializable]
    public class Updates
    {
        /// <summary>
        /// Тип события
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Идентификатор события
        /// </summary>
        [JsonPropertyName("event_id")]
        public string? EventId { get; set; }

        /// <summary>
        /// версия API, для которой сформировано событие
        /// </summary>
        [JsonPropertyName("v")]
        public double? CallBackVersion { get; set; }

        /// <summary>
        /// Объект, инициировавший событие
        /// Структура объекта зависит от типа уведомления
        /// </summary>
        [JsonPropertyName("object")]
        public JsonObject? Object { get; set; }

        /// <summary>
        /// ID сообщества, в котором произошло событие
        /// </summary>
        [JsonPropertyName("group_id")]
        public long GroupId { get; set; }
    }
}
