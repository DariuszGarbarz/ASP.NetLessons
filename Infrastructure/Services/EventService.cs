using AutoMapper;
using Core.Domain;
using Core.Repositories;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<EventDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
            return _mapper.Map<EventDto>(@event);
        }

        public async Task<EventDto> GetAsync(string name)
        {
            var @event = await _eventRepository.GetAsync(name);
            return _mapper.Map<EventDto>(@event);
        }


        public async Task<IEnumerable<EventDto>> BrowseAsync(string name = null)
        {
            var events = await _eventRepository.BrowseAsync(name);

            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task CreateAsync(Guid id, string name, string description, DateTime startDate, DateTime endDate)
        {
            var @event = await _eventRepository.GetAsync(name);
            if(@event != null)
            {
                throw new Exception($"Event named:'{name}' already exist.");
            }
            @event = new Event(id, name, description, startDate, endDate);
            await _eventRepository.AddAsync(@event);
        }

        public async Task AddTicketsAsync(Guid eventId, int amount, decimal price)
        {
            var @event = await _eventRepository.GetAsync(eventId);
            if (@event == null)
            {
                throw new Exception($"Event with:'{eventId}' doesn't exist.");
            }
            @event.AddTickets(amount, price);
            // for future sql database
            await _eventRepository.UpdateAsync(@event);
        }





        public async Task UpdateAsync(Guid id, string name, string description)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

       

        
    }
}
