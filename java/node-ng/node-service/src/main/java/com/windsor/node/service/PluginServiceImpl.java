package com.windsor.node.service;

import static com.windsor.node.util.IOUtil.getExistentFile;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Enumeration;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;

import org.apache.commons.io.FileUtils;
import org.apache.commons.io.FilenameUtils;
import org.apache.commons.io.IOUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.PropertySource;
import org.springframework.stereotype.Service;

import com.windsor.node.common.domain.PluginMetaData;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.domain.entity.Exchange;
import com.windsor.node.domain.entity.Plugin;
import com.windsor.node.domain.entity.ServiceType;
import com.windsor.node.plugin.BaseWnosPlugin;
import com.windsor.node.plugin.CachingPluginClassLoader;
import com.windsor.node.repo.ExchangeRepository;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.util.IOUtil;

/**
 * Provides an implementation of the plugin service.
 */
@PropertySource("classpath:nos.properties")
@Service
public class PluginServiceImpl implements PluginService {

    private final static Logger logger = LoggerFactory.getLogger(PluginServiceImpl.class);

    @Autowired
    private ExchangeRepository exchangeRepository;

    /**
     * Path to the directory where plugins are stored.
     */
    @Value("${path.plugin.dir}")
    private String pluginDirectory;

    private CachingPluginClassLoader cachingPluginClassLoader;

    public PluginServiceImpl() {

    }

    @Override
    public List<ServiceType> transform(List<com.windsor.node.common.domain.ServiceType> serviceTypes) {

        List<ServiceType> serviceTypesOut = new ArrayList<>();

        for(com.windsor.node.common.domain.ServiceType foreignServiceType : serviceTypes) {
            serviceTypesOut.add(ServiceType.valueOf(foreignServiceType.toString()));
        }

        if(serviceTypesOut.size() < 1) {
            serviceTypesOut = Arrays.asList(ServiceType.values());
        }

        return serviceTypesOut;
    }

    public File getPluginDirectory() {
        return new File(pluginDirectory);
    }

    @Override
    public BaseWnosPlugin getPlugin(Exchange exchange, String implementorClass) throws IOException {
        exchange = exchangeRepository.findOne(exchange.getId());
        File contentDirectory = getContentDirectory(exchange);
        return (BaseWnosPlugin) getCachingPluginClassLoader().getPluginInstance(contentDirectory, implementorClass);
    }

    @Override
    public List<PluginServiceImplementorDescriptor> getImplementors(Exchange exchange) throws IOException {
        File contentDirectory = getContentDirectory(exchange);
        return getCachingPluginClassLoader().getPluginServiceImplementorDescriptors(contentDirectory);
    }

    @Override
    public PluginMetaData getPluginMetadata(Exchange exchange) throws IOException {
        exchange = exchangeRepository.findOne(exchange.getId());
        File contentDirectory = getContentDirectory(exchange);
        return getCachingPluginClassLoader().getPluginMetaData(contentDirectory);
    }

    private CachingPluginClassLoader getCachingPluginClassLoader() {

        if(cachingPluginClassLoader == null) {
            cachingPluginClassLoader = new CachingPluginClassLoader();
        }

        return cachingPluginClassLoader;
    }

    private File getContentDirectory(Exchange exchange) throws IOException {

        File contentDirectory = null;

        File fileExchange = new File(getPluginDirectory().getAbsolutePath() + "/" + exchange.getName());

        // make sure the plugin directory exists
        if(!fileExchange.exists()) {
            fileExchange.mkdirs();
        }

        Plugin plugin = exchange.getCurrentPlugin();
        if(plugin != null) {

            File filePlugin = new File(fileExchange.getAbsolutePath() + "/" + plugin.getId());
            contentDirectory = filePlugin;

            if(!filePlugin.exists()) {

                filePlugin.mkdirs();
                unzipPluginData(filePlugin, plugin);
            }
        }

        return contentDirectory;
    }

    private void unzipPluginData(File unzipDirectory, Plugin plugin) throws IOException {

        // create a temp directory
        Path pathTemp = Files.createTempDirectory(plugin.getId());

        // create temp file for the plugin data
        File fileTemp = new File(pathTemp.toFile().getAbsolutePath() + "/" + UUIDGenerator.makeId());
        FileUtils.forceDeleteOnExit(fileTemp);

        // write out the plugin data
        FileUtils.writeByteArrayToFile(fileTemp, plugin.getContent());
        unzip(fileTemp.getAbsolutePath(), unzipDirectory.getAbsolutePath());
    }

    /**
     * Generic method to unzip the source ZIP archive into the provided path.
     *
     * @param sourceFilePath String with the path to ZIP archive to extract
     * @param targetDirPath String with the path to the extraction directory
     * @throws IOException Any problem reading or writing data
     */
    private void unzip(String sourceFilePath, String targetDirPath) throws IOException {

        Enumeration<? extends ZipEntry> entries = null;
        ZipFile zipFile = null;

        zipFile = new ZipFile(getExistentFile(sourceFilePath));
        entries = zipFile.entries();

        while (entries.hasMoreElements()) {

            ZipEntry entry = entries.nextElement();
            String entryName = entry.getName();

                /* if the zipEntry name ends with / it's a directory */
            if (entry.isDirectory()) {

                logger.debug("Extracting directory: " + entryName);

                String dirPath = FilenameUtils.concat(targetDirPath, entryName);
                FileUtils.forceMkdir(new File(dirPath));

                continue;

                /*
                 * else if the entry is a file, but is nested in one or more
                 * directories, make the directory
                 */
            } else if (entryName.contains("/")) {

                String zipPath = FilenameUtils.getPath(entryName);
                String baseDirName = FilenameUtils.concat(targetDirPath,
                        zipPath);
                File basedir = new File(baseDirName);

                if (!basedir.exists()) {
                    FileUtils.forceMkdir(basedir);
                }

            }

            String targetPath = FilenameUtils.concat(targetDirPath, IOUtil
                    .cleanForPath(entryName));

            logger.debug("Extracting file: " + entryName + " to: "
                    + targetPath);
            IOUtils.copy(zipFile.getInputStream(entry), new FileOutputStream(targetPath));
        }

        zipFile.close();
    }
}
