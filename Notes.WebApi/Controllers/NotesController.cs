﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.WebApi.Models;

namespace Notes.WebApi.Controllers
{
    /// <summary>
    /// Контроллер для управления сущностью "Заметка".
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : BaseController
    {
        private readonly IMapper _mapper;

        public NotesController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получить список всех заметок.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        /// <summary>
        /// Получить заметку
        /// </summary>
        /// <param name="id"></param>
        /// <returns>доп. информация</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> Get([FromQuery] Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var viewModel = await Mediator.Send(query);
            return Ok(viewModel);
        }

        /// <summary>
        /// Создание заметки.
        /// </summary>
        /// <param name="createNoteDto">модель создания заметки</param>
        /// <returns>guid</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        /// <summary>
        /// Обновление заметки.
        /// </summary>
        /// <param name="updateNoteDto"></param>
        /// <returns>response</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Удаление заметки.
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>response</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}