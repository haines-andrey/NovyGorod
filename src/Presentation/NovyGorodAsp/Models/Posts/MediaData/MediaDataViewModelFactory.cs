using System;
using NovyGorod.Application.Contracts.Media.Dto;
using NovyGorodAsp.Models.Posts.MediaData.Settings;

namespace NovyGorodAsp.Models.Posts.MediaData;

public static class MediaDataViewModelFactory
{
    public static MediaDataViewModel Create(MediaDataDto mediaData)
    {
        return new MediaDataViewModel {MediaData = mediaData};
    }

    public static MediaDataViewModel WithImageSettings(
        this MediaDataViewModel viewModel,
        Action<ImageSettings> builder)
    {
        var settings = new ImageSettings();
        builder(settings);
        viewModel.ImageSettings = settings;

        return viewModel;
    }
    
    public static MediaDataViewModel WithVideoSettings(
        this MediaDataViewModel viewModel,
        Action<VideoSettings> builder)
    {
        var settings = new VideoSettings();
        builder(settings);
        viewModel.VideoSettings = settings;

        return viewModel;
    }
}