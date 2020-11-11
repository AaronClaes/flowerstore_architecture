using System.Collections.Generic;
using AutoMapper;
using FlowerStoreAPI.Dtos;
using FlowerStoreAPI.Dtos.FlowerDTOS;
using FlowerStoreAPI.Models;
using FlowerStoreAPI.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace FlowerStoreAPI.Controllers
{
    [Route("api/flowers")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerRepo _repository;
        private readonly IMapper _mapper;

        public FlowersController(IFlowerRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/flowers
        [HttpGet]

        public ActionResult<IEnumerable<FlowerReadDto>> GetAllFlowers()
        {
            var flowerItems = _repository.GetAllFlowers();

            return Ok(_mapper.Map<IEnumerable<FlowerReadDto>>(flowerItems));
        }


        //GET api/flowers/{id}
        [HttpGet("{id}")]
        public ActionResult<FlowerReadDto> GetFlowerById(int id)
        {
            var flowerItem = _repository.GetFlowerById(id);
            if (flowerItem != null)
            {
                return Ok(_mapper.Map<FlowerReadDto>(flowerItem));
            }
            return NotFound();

        }

        //POST api/flowers
        [HttpPost]
        public ActionResult<FlowerReadDto> CreateFlower(FlowerCreateDto flowerCreateDto)
        {

            var flowerModel = _mapper.Map<Flower>(flowerCreateDto);
            _repository.CreateFlower(flowerModel);
            _repository.SaveChanges();

            var flowerReadDto = _mapper.Map<FlowerReadDto>(flowerModel);

            return CreatedAtRoute(nameof(GetFlowerById), new { Id = flowerReadDto.Id }, flowerReadDto);
        }


        //PUT api/flowers/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFlower(int id, FlowerUpdateDto flowerUpdateDto)
        {
            var flowerModelFromRepo = _repository.GetFlowerById(id);
            if (flowerModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(flowerUpdateDto, flowerModelFromRepo);

            _repository.UpdateFlower(flowerModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }


        //DELETE api/flowers/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFlower(int id)
        {
            var flowerModelFromRepo = _repository.GetFlowerById(id);
            if (flowerModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteFlower(flowerModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}



