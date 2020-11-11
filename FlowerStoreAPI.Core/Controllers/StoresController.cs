using System.Collections.Generic;
using AutoMapper;
using FlowerStoreAPI.Dtos;
using FlowerStoreAPI.Dtos.FlowerDTOS;
using FlowerStoreAPI.Dtos.StoreDTOS;
using FlowerStoreAPI.Models;
using FlowerStoreAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStoreAPI.Controllers
{   
    [Route("api/stores")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepo _repository;
        private readonly IMapper _mapper;
        
        public StoreController(IStoreRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        //GET api/stores
        [HttpGet]
        public  ActionResult <IEnumerable<StoreReadDto>> GetAllStores()
        {
            var storeItems = _repository.GetAllStores();

            return Ok(_mapper.Map<IEnumerable<StoreReadDto>>(storeItems));
        }


        //GET api/stores/{id}
        [HttpGet("{id}")]
        public ActionResult <StoreReadDto> GetStoreById(int id)
        {
            var storeItem = _repository.GetStoreById(id);
            if(storeItem != null)
            {
                return Ok(_mapper.Map<StoreReadDto>(storeItem));
            }
            return NotFound();

        }


        //POST api/stores
        [HttpPost]
        public ActionResult <StoreReadDto> CreateStore(StoreCreateDto storeCreateDto){

            var storeModel = _mapper.Map<Store>(storeCreateDto);
            _repository.CreateStore(storeModel);
            _repository.SaveChanges();

            var storeReadDto = _mapper.Map<StoreReadDto>(storeModel);

            return CreatedAtRoute(nameof(GetStoreById), new{Id = storeReadDto. Id}, storeReadDto);
        }


        //PUT api/stores/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateStore(int id, StoreUpdateDto storeUpdateDto)
        {
            var storeModelFromRepo = _repository.GetStoreById(id);
            if(storeModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(storeUpdateDto, storeModelFromRepo);

            _repository.UpdateStore(storeModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        //DELETE api/stores/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteStore(int id)
        {
            var storeModelFromRepo = _repository.GetStoreById(id);
            if(storeModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteStore(storeModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}

    

